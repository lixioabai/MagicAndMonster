using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RPGMotor : MonoBehaviour
{
    [HideInInspector]
    public bool nomoveit=true;
    public class Force
    {
        public float Time;
        public float Elapsed;
        public Action<Force> OnDone;
        public Vector3 From;
        public Vector3 To;
    }

    public class Ground                 //接触物体类
    {
        public Vector3 Point { get { return Hit.point; } }
        public Vector3 Normal { get { return Hit.normal; } }
        public Transform Transform { get { return Hit.transform; } }

        public RaycastHit Hit;
        public bool IsTouching;
        public Vector3 Offset;

        public Ground(RaycastHit hit, bool isTouching)       //构造方法，获取碰撞物体信息
        {
            Hit = hit;
            IsTouching = isTouching;
        }
    }

    [Serializable]
    public class CollisionSphere
    {
        public float Offset;
        public bool IsFeet;
        public bool IsHead;

        public CollisionSphere()
        {

        }

        public CollisionSphere(float offset, bool isFeet, bool isHead)
        {
            Offset = offset;
            IsFeet = isFeet;
        }
    }

    float lastGroundTouch = 0f;                         //最后接触地面

    HashSet<string> expiredForces = new HashSet<string>();
    Dictionary<string, Force> forces = new Dictionary<string, Force>();

    [SerializeField]
    bool displayConfigGizmos = true;                    //显示配置设置

    [SerializeField]
    bool displayDebugInfo = true;                       //显示线

    [SerializeField]
    bool displayExtendedDebugInfo = true;           //显示扩展的调试信息

    [SerializeField]
    Transform target = null;

    [SerializeField]
    CollisionSphere[] spheres = 
        new CollisionSphere[3] {
            new CollisionSphere(0.4f, true, false),
            new CollisionSphere(0.75f, false, false),
            new CollisionSphere(1.15f, false, true),
        };

    [SerializeField]
    float bodyRadius = 0.4f;                                                //半径

    [SerializeField]
    float fallClampEpsilon = 0.025f;

    [SerializeField]
    float moveClampEpsilon = 0.2f;

    [SerializeField]
    float maxSimulationTime = 0.01f;

    [SerializeField]
    LayerMask walkable = 0;

    [SerializeField]
    public bool gravityEnabled = true;

    [SerializeField]
    Vector3 gravityForce = new Vector3(0, -10, 0);

    [SerializeField]
    Vector3 jumpForce = new Vector3(0, 20, 0);

    [SerializeField]
    float jumpTime = 0.75f;

    [SerializeField]
    float slideAngle = 45f;

    [SerializeField]
    float slideSpeedModifier = 0.5f;

    [SerializeField]
    float slideMagnitude = 0.5f;

    [SerializeField]
    bool rigidbodyTransferEnabled = true;

    [SerializeField]
    float rigidbodyTransferTime = 1f;

    [SerializeField]
    float rigidbodyTransferAmount = 1f;

    [HideInInspector]
    public Vector3 MovementInput;

    [HideInInspector]
    public float MovementSpeed = 4f;

    public Action OnJump { get; set; }
    public Action OnLand { get; set; }
    public Action OnIdle { get; set; }
    public Action OnMove { get; set; }
    public Action OnFall { get; set; }
    public Action OnSlide { get; set; }

    public bool IsJumping { get; private set; }
    public float DeltaTime { get; private set; }
    public Ground CurrentGround { get; private set; }
    public bool HasGround { get { return CurrentGround != null; } }
    public bool IsSliding { get; private set; }
    public bool IsAtt { get;  set; }
    public float GroundDelta { get { return Time.time - lastGroundTouch; } }
    public bool IsTouchingGround { get { return HasGround && CurrentGround.IsTouching; } }

    public void Yaw(float angles)
    {
        target.RotateAround(this.transform.position,Vector3.up, angles*2f);
    }               //人物转向

    public void SetYaw(float angles)
    {
        target.rotation = Quaternion.Euler(0f, angles, 0f);
    }

    public void AddForce(string name, Vector3 from, Vector3 to, float time)
    {
        AddForce(name, from, to, time, null);
    }

    public void AddForce(string name, Vector3 from, Vector3 to, float time, Action<Force> onDone)
    {
        if (!String.IsNullOrEmpty(name))
        {
            forces[name] = new Force { From = from, To = to, Time = time, Elapsed = 0, OnDone = onDone };

            expiredForces.Remove(name);
        }
    }

    public void RemoveForce(string name)
    {
        if (!String.IsNullOrEmpty(name))
        {
            expiredForces.Add(name);
        }
    }
    public void RemoveForce()
    {
        foreach (string name in expiredForces)
        {
            forces.Remove(name);
        }
        expiredForces.Clear();
    }

    public Force GetForce(string name)
    {
        Force f;

        if (forces.TryGetValue(name, out f))
        {
            return f;
        }

        return null;
    }

    public bool Jump()
    {
        if (HasGround && CurrentGround.IsTouching && !IsJumping && !IsSliding&&!IsAtt)
        {
            IsJumping = true;

            AddForce("Jump", jumpForce, Vector3.zero, jumpTime, JumpDone);

            if (MovementInput != Vector3.zero)
            {
                AddForce("JumpMomentum", MovementInput * 4f, MovementInput * 4f, jumpTime);
            }

            InvokeCallback(OnJump);

            return true;
        }

        return false;
    }

    void InvokeCallback(Action action)          //回调
    {
        if (action != null)
        {
            action();
        }
    }

    void RemoveExpiredForces()          //删除过期的力
    {
        foreach (string name in expiredForces)
        {
            forces.Remove(name);
        }

        expiredForces.Clear();
    }

    void JumpDone(Force f)
    {
        Force jumpMomentum = GetForce("JumpMomentum");

        IsJumping = false;
        RemoveForce("Jump");
        RemoveForce("JumpMomentum");

        if ((!HasGround || !CurrentGround.IsTouching) && jumpMomentum != null)
        {
            AddForce("FallMomentum", jumpMomentum.From, Vector3.zero, 1f);
        }
    }

    void OnTriggerStay(Collider c)
    {
        OnTriggerEnter(c);
    }

    void OnTriggerEnter(Collider c)
    {
        if (rigidbodyTransferEnabled)
        {
            if (c.GetComponent<Rigidbody>() == null)
            {
                return;
            }

            if (((1 << c.gameObject.layer) & (int)walkable) != 0)
            {
                Vector3 v = c.GetComponent<Rigidbody>().velocity.normalized;
                Vector3 d = (target.position - c.transform.position).normalized;

                float a = Vector3.Angle(v, d);

                if (a < 90f)
                {
                    float t = (90f - a) / 90f;
                    float m = c.GetComponent<Rigidbody>().velocity.magnitude;

                    AddForce("Rigidbody#" + c.GetComponent<Rigidbody>().GetInstanceID(), m * d * rigidbodyTransferAmount * t, Vector3.zero, rigidbodyTransferTime);
                }
            }
        }
    }

    void Start()
    {
        if (target == null)
        {
            target = transform;
        }

        if (spheres == null || spheres.Length == 0)
        {
            enabled = false;
            Debug.LogError("[RPGMotor] No spheres found, disabling");
        }

        bool foundFeet = false;
        bool foundHead = false;

        for (int i = 0; i < spheres.Length; ++i)
        {
            if (spheres[i] != null && spheres[i].IsFeet)
            {
                if (foundFeet)
                {
                    enabled = false;
                    Debug.LogError("[RPGMotor] More then one feet sphere found, disabling");
                    return;
                }

                foundFeet = true;
            }

            if (spheres[i] != null && spheres[i].IsHead)
            {
                if (foundHead)
                {
                    enabled = false;
                    Debug.LogError("[RPGMotor] More then one head sphere found, disabling");
                    return;
                }

                foundHead = true;
            }
        }

        if (!foundFeet)
        {
            enabled = false;
            Debug.LogError("[RPGMotor] No feet sphere found, disabling");
        }

        if (!foundHead)
        {
            enabled = false;
            Debug.LogError("[RPGMotor] No head sphere found, disabling");
        }
    }

    void LateUpdate()
    {
        //当有一个ground时并接触它，我们应确保在它移动时跟随它
        //if (HasGround && CurrentGround.IsTouching && CurrentGround.Offset != Vector3.zero && nomoveit)
        //{
        //    target.position = CurrentGround.Transform.position + CurrentGround.Offset;
        //}

        float delta = Time.deltaTime;

        while (delta > maxSimulationTime)
        {
            DeltaTime = maxSimulationTime;

            Step();

            delta -= maxSimulationTime;
        }

        if (delta > 0f)
        {
            DeltaTime = delta;

            Step();
        }

        if (HasGround && CurrentGround.IsTouching)
        {
            CurrentGround.Offset = target.position - CurrentGround.Transform.position;
        }

        MovementInput = Vector3.zero;
    }

    void OnDrawGizmos()
    {
        if (displayConfigGizmos)
        {
            if (spheres != null)
            {
                for (int i = 0; i < spheres.Length; ++i)
                {
                    Gizmos.color = spheres[i].IsFeet ? Color.green : (spheres[i].IsHead ? Color.yellow : Color.cyan);
                    Gizmos.DrawWireSphere(OffsetPosition(spheres[i].Offset), bodyRadius);
                }
            }
        }
    }

    void StopSliding()
    {
        if (IsSliding)
        {
            IsSliding = false;

            if (displayDebugInfo)
            {
                //Debug.Log("[RPGMotor] Sliding Stopped");
            }
        }
    }

    bool CalculateSlide()
    {
        Vector3 n = CurrentGround.Normal;
        float a = Vector3.Angle(n, Vector3.up);
        bool slide = true;

        //如果站在一定角度的坡度上会向下滑落
        if (a > slideAngle)
        {
            Vector3 v = Vector3.Cross(n, Vector3.down);
            v = Vector3.Cross(v, n);

            RaycastHit hit;

            if (Physics.Raycast(target.position, v, out hit) && !IsSliding)
            {
                if ((target.position - hit.point).magnitude <= slideMagnitude)
                {
                    StopSliding();
                    slide = false;
                }
            }

            if (slide)
            {
                target.position += (v * gravityForce.magnitude * DeltaTime * slideSpeedModifier);

                FindGround(moveClampEpsilon);
                InvokeCallback(OnSlide);

                if (!IsSliding)
                {
                    IsSliding = true;

                    if (displayDebugInfo)
                    {
                        //Debug.Log("[RPGMotor] Sliding Started");
                    }
                }
            }
        }
        else
        {
            StopSliding();
        }

        return IsSliding;
    }

    void Step()
    {
        CalculateForces();

        if (HasGround && CurrentGround.IsTouching)
        {
            if (!CalculateSlide())
            {
                if (!IsJumping && MovementInput != Vector3.zero)
                {
                    CalculateMovement();
                    InvokeCallback(OnMove);

                    if (HasGround && !CurrentGround.IsTouching)
                    {
                        AddForce("FallMomentum", MovementInput * MovementSpeed, Vector3.zero, 1f);
                    }
                }
                else
                {
                    InvokeCallback(OnIdle);
                    FindGround(fallClampEpsilon);
                }
            }
        }
        else
        {
            if (gravityEnabled)
            {
                CalculateGravity();
            }

            FindGround(fallClampEpsilon);

            if (!HasGround || !CurrentGround.IsTouching)
            {
                InvokeCallback(OnFall);
            }
        }

        PushBack();
    }

    void PushBack()
    {
        if (spheres != null)
        {
            for (int i = 0; i < spheres.Length; ++i)
            {
                CollisionSphere s = spheres[i];

                if (s != null)
                {
                    foreach (Collider collider in Physics.OverlapSphere(OffsetPosition(s.Offset), bodyRadius, walkable))
                    {
                        Vector3 position = OffsetPosition(s.Offset);
                        Vector3 contactPoint = Vector3.zero;

                        if (collider is BoxCollider)
                        {
                            contactPoint = RPGCollisions.ClosestPointOn((BoxCollider)collider, position);
                        }
                        else if (collider is SphereCollider)
                        {
                            contactPoint = RPGCollisions.ClosestPointOn((SphereCollider)collider, position);
                        }
                        else if (collider is MeshCollider)
                        {
                            RPGMesh rpgMesh = collider.GetComponent<RPGMesh>();

                            if (rpgMesh != null)
                            {
                                contactPoint = rpgMesh.ClosestPointOn(position, bodyRadius, displayDebugInfo, displayExtendedDebugInfo);
                            }
                            else
                            {
                                MeshCollider mc = (MeshCollider)collider;
                                
                                if (mc.convex)
                                {
                                    contactPoint = mc.ClosestPointOnBounds(position);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        else if (collider is CapsuleCollider)
                        {

                        }
                        else if (collider is TerrainCollider)
                        {
                            
                        }
                        else if (collider is WheelCollider)
                        {
                            Debug.LogWarning("[RPGMotor] WheelColliders not supported");
                        }
                        else
                        {
                            continue;
                        }

                        if (contactPoint != Vector3.zero)
                        {
                            //如果这个sphere是脚
                            //我们接触一个地面
                            //并且球的位置在接触位置之上
                            //我们应该忽略它
                            if (s.IsFeet && HasGround && CurrentGround.IsTouching && position.y > contactPoint.y)
                            {
                                continue;
                            }

                            //如果这个球是头
                            //并且跳跃
                            //并且撞到了头，就终止跳跃
                            if (s.IsHead && IsJumping && contactPoint.y > (position.y + bodyRadius * 0.25f))
                            {
                                JumpDone(null);
                            }

                            Vector3 v = position - contactPoint;

                            if (displayDebugInfo)
                            {
                                Debug.DrawLine(position, contactPoint, Color.red);
                            }

                            if (displayExtendedDebugInfo)
                            {
                                //Debug.Log("[RPGMotor] Contact point " + contactPoint);
                            }

                            target.position += Vector3.ClampMagnitude(v, Mathf.Clamp(bodyRadius - v.magnitude, 0, bodyRadius));
                        }
                    }
                }
            }
        }
    }

    void CalculateForces()
    {
        RemoveExpiredForces();

        foreach(KeyValuePair<string, Force> kvp in forces.Select(x => x).ToList())
        {
            Force f = kvp.Value;

            // Increase elapsed time
            f.Elapsed += DeltaTime;

            // If more then .Time has passed, we're done
            if (f.Elapsed / f.Time >= 1f)
            {
                if (f.OnDone != null)
                {
                    f.OnDone(f);
                }

                expiredForces.Add(kvp.Key);
            }
            else
            {
                // Move our target
                target.Translate(Vector3.Lerp(f.From, f.To, f.Elapsed / f.Time) * DeltaTime);
            }
        }
    }

    void CalculateGravity()
    {
        target.Translate(gravityForce * DeltaTime);
    }

    void CalculateMovement()
    {
        Vector3 oldPosition = target.position;

        float movementDistance = DeltaTime * MovementSpeed;             //移动距离

        target.Translate(MovementInput.normalized * movementDistance);  //移动我们的角色

        FindGround(moveClampEpsilon);           //寻找一个新的地面

        if (!HasGround)             //确保有一个地面
        {
            return;
        }

        Vector3 realMovement = target.position - oldPosition;       //实际移动

        if (realMovement.magnitude > movementDistance)
        {
            realMovement = Vector3.ClampMagnitude(realMovement, movementDistance);

            target.position = oldPosition + realMovement;

            FindGround(moveClampEpsilon);
        }
    }

    void ClampToGround()
    {
        //if (displayDebugInfo && displayExtendedDebugInfo && (target.position.y - CurrentGround.Point.y) > 0)
        //{
        //    Debug.Log("[RPGMotor] Clamping to ground, distance: " + (target.position.y - CurrentGround.Point.y));
        //}

        target.position = new Vector3(target.position.x, CurrentGround.Point.y, target.position.z);
    }

    void FindGround(float clampEpsilon)
    {
        bool wasFalling = HasGround && !CurrentGround.IsTouching;

        RaycastHit[] above;
        RaycastHit[] below;

        FindGroundPoints(target.position, out above, out below);

        if (HasGround && above.Length > 0)
        {
            for (int i = ReferenceEquals(above[0].transform, CurrentGround.Transform) ? 1 : 0; i < above.Length; ++i)
            {
                if ((target.position - above[i].point).magnitude <= clampEpsilon)
                {
                    CurrentGround = new Ground(above[i], true);
                    goto done;
                }
            }

            for (int i = 0; i < above.Length; ++i)
            {
                // This means we have stepped through or fallen through a piece of ground
                if (ReferenceEquals(above[i].transform, CurrentGround.Transform) && (target.position - above[i].point).magnitude < 0.5)
                {
                    CurrentGround = new Ground(above[i], true);
                    goto done;
                }
            }
        }

        if (below.Length > 0)
        {
            CurrentGround = new Ground(below[0], (target.position - below[0].point).magnitude <= clampEpsilon);
        }
        else
        {
            CurrentGround = null;
        }

    done:

        if (HasGround && CurrentGround.IsTouching)
        {
            if (wasFalling && OnLand != null)
            {
                OnLand();
            }

            if (IsJumping)
            {
                JumpDone(null);
            }

            ClampToGround();
            RemoveForce("FallMomentum");
            lastGroundTouch = Time.time;
        }
    }

    bool FindGroundPoints(Vector3 point, out RaycastHit[] above, out RaycastHit[] below)
    {
        Vector3 o = new Vector3(point.x, 2048f, point.z);
        Vector3 d = Vector3.down;

        RaycastHit hit;
        RaycastHit[] all = Physics.RaycastAll(o, d, 4096, walkable);

        if (all.Length > 0)
        {
            List<RaycastHit> hits = new List<RaycastHit>();

            int maxIndex = all.Length - 1;

            for (int i = 0; i < all.Length; ++i)
            {
                hit = all[i];
                hits.Add(hit);

                while (true)
                {
                    o = hit.point;
                    o.y -= 0.1f;

                    if (i < maxIndex && all[i + 1].point.y > o.y)
                    {
                        break;
                    }

                    if (Physics.Raycast(o, d, out hit, 4096, walkable))
                    {
                        if (i < maxIndex && all[i + 1].point.y >= hit.point.y && hit.transform == all[i + 1].transform)
                        {
                            break;
                        }

                        hits.Add(hit);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            above = hits.Where(x => x.point.y > point.y).OrderBy(x => (x.point - point).magnitude).ToArray();
            below = hits.Where(x => x.point.y <= point.y).OrderBy(x => (x.point - point).magnitude).ToArray();

            if (displayDebugInfo)
            {
                Vector3 b = Vector3.back * 0.25f;
                Vector3 f = Vector3.forward * 0.25f;

                foreach (RaycastHit h in above)
                {
                    Debug.DrawLine(h.point + b, h.point + f, Color.yellow);
                }

                foreach (RaycastHit h in below)
                {
                    Debug.DrawLine(h.point + b, h.point + f, Color.green);
                }
            }

            return hits.Count > 0;
        }

        above = new RaycastHit[0];
        below = new RaycastHit[0];
        return false;
    }

    Vector3 OffsetPosition(float y)
    {
        Vector3 p;

        if (target == null)
        {
            p = transform.position;
        }
        else
        {
            p = target.position;
        }

        p.y += y;

        return p;
    }

}