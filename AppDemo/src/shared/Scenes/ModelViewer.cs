using Microsoft.Xna.Framework;
using VerticesEngine;
using VerticesEngine.ContentManagement;
using VerticesEngine.Graphics;
using VerticesEngine.Screens;

namespace Virtex.App.VerticesTechDemo
{
    public class ModelViewerScene : vxModelViewer
    {
        public ModelViewerScene():base()
        {

        }
		float height = 0;


        protected override vxEntity3D LoadModel()
        {
            //vxMesh model = Engine.InternalAssets.Models.UnitCylinder;

			vxMesh model = vxContentManager.Instance.LoadModel("Models/items/rock/model");
			vxEntity3D entity = new vxEntity3D(this, model, Vector3.Zero);
			height = entity.BoundingShape.Radius/4;
			return entity;
        }

   //     public override void UpdateModel(GameTime gameTime)
   //     {
   //         // Calculate the camera matrices.
   //         float time = (float)gameTime.TotalGameTime.TotalSeconds;

   //         //Matrix rotation = Matrix.CreateRotationY(time * 0.5f);
   //         Matrix rotation = Matrix.Identity;

			//Vector3 pos = new Vector3(0, height, 0);

   //         Model.WorldTransform =
   //             Matrix.CreateScale(0.35f) *
   //             Matrix.CreateRotationX(-MathHelper.PiOver2) * rotation *
			//	     Matrix.CreateTranslation(0, height, 0);
			
			////foreach (vxMeshMesh mesh in this.Model.Model.ModelMeshes)
			////{
			////		foreach (EffectParameter para in mesh.UtilityEffect.Parameters)
			////		{
			////			vxConsole.WriteToInGameDebug(para.Name + " : " + para.ParameterClass + " : " + para.ParameterType + " : " + vxEffect.GetParameterValue(para));
			////			//vxConsole.WriteToInGameDebug(para.Name + " : " + para.ParameterClass + " : " + para.ParameterType + " : " + para.Elements.Count);
			////		}
			////	}
			//}
        }
    }

