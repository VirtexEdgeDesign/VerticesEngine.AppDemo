using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using VerticesEngine;
using VerticesEngine.Input;

namespace VerticesEngine.AppDemo
{
    internal class CarChaseCamera : vxComponent
    {
        public vxCameraChaseController ChaseCamera;

        Vector3[] OffsetPositions;
        int activeOffset = 0;

        public vxTransform EntityTransform
        {
            get { return ((vxEntity3D)Entity).Transform; }
        }

        protected override void PostUpdate()
        {
            base.PostUpdate();

            if (OffsetPositions == null || OffsetPositions.Length == 0)
            {
                List<Vector3> vec = new List<Vector3>();

                vec.Add(new Vector3());
                vec.Add(new Vector3(0, 0.2f, 1.5f));
                vec.Add(new Vector3(0, 0.3f, 2.5f));

                OffsetPositions = vec.ToArray();
            }


            if (vxInput.IsNewKeyPress(Keys.C) || vxInput.IsNewButtonPressed(Buttons.Y))
            {
                activeOffset = (activeOffset + 1) % OffsetPositions.Length;
            }

            // let's transform the offset here
            var camOffset = Vector3.Transform(OffsetPositions[activeOffset], EntityTransform.Rotation);

            
            ChaseCamera.DesiredPositionOffset = new Vector3(0.0f, 1.5f / 2, 4.5f / 0.5f);
            ChaseCamera.LookAtOffset = new Vector3(0.0f, 0.50f, 0.0f);
            ChaseCamera.Stiffness = 877; // 450000 * (2) * 0.975f;
            ChaseCamera.Damping = 18.5775f; //35000 / (2.2f * 0.85f);

            // Set Chase Data
            ChaseCamera.ChasePosition = EntityTransform.Position + EntityTransform.Forward + camOffset;
            ChaseCamera.ChaseDirection = vxMathHelper.Smooth(ChaseCamera.ChaseDirection, EntityTransform.Forward, 2);
            ChaseCamera.Up = vxMathHelper.Smooth(ChaseCamera.Up, EntityTransform.Up, 2);

        }
    }
}
