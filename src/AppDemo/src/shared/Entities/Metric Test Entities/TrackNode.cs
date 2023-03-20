

//using Microsoft.Xna.Framework;
//using System;
//using System.Linq;
//using VerticesEngine;
//using VerticesEngine.ContentManagement;
//using VerticesEngine.Diagnostics;
//using VerticesEngine.Graphics;

//namespace VerticesDemo
//{
//    public enum FalloffType
//    {
//        Linear,
//        Parabolic,
//        InverseParabolic,
//        InvTangent
//    }
//    public class TrackNode : vxEntity3D
//    {
//        public FalloffType FalloffType;

//        TrackEntity TrackEntity;
//        float Radius = 10;
//        public TrackNode(vxGameplayScene3D scene, TrackEntity TrackEntity, Vector3 StartPosition, float Radius,
//                         FalloffType FalloffType = FalloffType.InvTangent)
//            : base(scene, StartPosition)
//        {
//            this.TrackEntity = TrackEntity;
            
//            prevPos = StartPosition;

//            this.Radius = Radius;
//            this.FalloffType = FalloffType;


//        }

//        protected override vxMesh OnLoadModel()
//        {
//            return vxContentManager.Instance.Load<vxMesh>("Models/track/node");
//        }


//        Vector3 delta;
//        Vector3 prevPos;

        

//        protected override void OnGimbalRotate(Vector3 axis, float delta)
//        {
//            base.OnGimbalRotate(axis, delta);

//                   vxDebug.DrawLine(Position,
//                                         Position + axis * 10,
//                                         Color.DeepPink);

//            //Vector3 d = Vector3.Transform(delta, Matrix.CreateRotationX(MathHelper.PiOver2));
//            Vector3 dVec = new Vector3(0);

//            //this.TrackEntity.Model.ModelMeshes[0].MeshParts[0].VerticesPoints
//            foreach (var part in TrackEntity.Model.Meshes[0].MeshParts)
//            {
//                for (int i = 0; i < part.MeshVertices.Count(); i++)
//                {
//                    Vector3 v = Vector3.Transform(part.MeshVertices[i].Position, TrackEntity.Transform.Matrix4x4Transform);
//                    float dist = MathHelper.Clamp(Math.Abs(v.Z - Position.Z) / Radius, 0, 1); ;
//                    float factor = 1;
//                    switch (FalloffType)
//                    {
//                        case FalloffType.Linear:
//                            factor = 1 - dist;
//                            break;
//                        case FalloffType.Parabolic:
//                            factor = (1 - dist) * (1 - dist);
//                            break;
//                        case FalloffType.InverseParabolic:
//                            factor = 1 - dist * dist;
//                            break;
//                        case FalloffType.InvTangent:
//                            // =(cos(x/10)+1)/2
//                            factor = (float)(Math.Cos(dist * MathHelper.Pi) + 1) / 2;
//                            break;
//                    }

//                    // Get the Flat Cross Section Point
//                    Vector3 planePoint = new Vector3(v.X, v.Y, 0) - Position;

//                    // Now Rotate The Point about the Axis
//                    //Vector3 RotatedPoint = Vector3.Transform(planePoint, Matrix.CreateRotationZ(delta));
//                    Vector3 RotatedPoint = Vector3.Transform(planePoint, Matrix.CreateFromAxisAngle(axis, delta));


//                    // Now get the difference between these points.
//                    dVec = RotatedPoint - planePoint;

//                    //Console.WriteLine(v);
//                    part.MeshVertices[i].Position += dVec * factor;

//                }

//                part.SetData();
//            }
//        }


//        protected override void OnWorldTransformChanged()
//        {
//            base.OnWorldTransformChanged();

//            delta = Position - prevPos;
//            //Console.WriteLine(delta);
//            prevPos = Position;


//            //Vector3 d = delta;

//            //this.TrackEntity.Model.ModelMeshes[0].MeshParts[0].VerticesPoints
//            if(TrackEntity != null)
//            foreach(var part in TrackEntity.Model.Meshes[0].MeshParts)
//            {
//                for (int i = 0; i < part.MeshVertices.Count(); i++)
//                {
//                    Vector3 v = Vector3.Transform( part.MeshVertices[i].Position, TrackEntity.Transform.Matrix4x4Transform);
//                    float dist = MathHelper.Clamp(Math.Abs(v.Z - Position.Z) / Radius, 0, 1);;
//                    float factor = 1;
//                    switch(FalloffType)
//                    {
//                        case FalloffType.Linear:
//                            factor = 1- dist;
//                            break;
//                        case FalloffType.Parabolic:
//                            factor = (1-dist) * (1-dist);
//                            break;
//                        case FalloffType.InverseParabolic:
//                            factor = 1 - dist * dist;
//                            break;
//                        case FalloffType.InvTangent:
//                            // =(cos(x/10)+1)/2
//                            factor = (float)(Math.Cos(dist * MathHelper.Pi)+1) / 2;
//                            break;
//                    }

//                    //Console.WriteLine(v);
//                    part.MeshVertices[i].Position += delta * factor;

//                }

//                part.SetData();
//            }
//        }
//    }
//}
