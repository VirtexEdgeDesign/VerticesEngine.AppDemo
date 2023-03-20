using BEPUphysics.Vehicle;
using Microsoft.Xna.Framework;
using VerticesEngine;
using VerticesEngine.ContentManagement;
using VerticesEngine.Graphics;

namespace VerticesEngine.AppDemo
{
    //[vxRegisterAsSandboxEntityAttribute("ForFiesta", SandboxCategories.GridItems, SandboxSubCategories.GridItems, "Models/vehicles/ford/model")]
    public class DrivableVehicleWheel : TechDemoItem
    {
        public Wheel Wheel;

        Vector3 whlPos;

        public DrivableVehicleWheel(vxGameplayScene3D scene, Vector3 position) :
            base(scene, null, Vector3.Zero)
        {
            whlPos = position;

            float Wheel_RAD = 0.625f;

            float Wheel_Friction = 4;

            float Wheel_Friction_Static = 5;

            float Susp_Stiff = 1000;

            float gripFriction = 3.5f;

            //The wheel model used is not aligned initially with how a wheel would normally look, so rotate them.
            //Matrix wheelGraphicRotation = Matrix.CreateFromAxisAngle(Vector3.Forward, MathHelper.PiOver2);

            var localWheelRotation = Quaternion.CreateFromAxisAngle(new Vector3(0, 0, 1), MathHelper.PiOver2);

            //The wheel model used is not aligned initially with how a wheel would normally look, so rotate them.
            Matrix wheelGraphicRotation = Matrix.CreateFromAxisAngle(Vector3.Forward, MathHelper.PiOver2);


            Wheel = new Wheel(
                new RaycastWheelShape(Wheel_RAD, Matrix.Identity),
                                         new WheelSuspension(Susp_Stiff, 75, Vector3.Down, 0.75f, new Vector3(whlPos.X, 0, whlPos.Z)),
                                         new WheelDrivingMotor(gripFriction, 300000000, 30000000),
                                         new WheelBrake(1.5f, 2, .02f),
                                         new WheelSlidingFriction(Wheel_Friction, Wheel_Friction_Static));

        }

        
        protected override vxMesh OnLoadModel()
        {
            return vxContentManager.Instance.Load<vxMesh>("Models/vehicles/lancer/wheel");
        }

        protected override void OnPhysicsColliderSetup()
        {

        }

        protected override void Update( )
        {
            Transform = Wheel.Shape.WorldTransform.ToTransform();

            base.Update();
        }
    }
}
