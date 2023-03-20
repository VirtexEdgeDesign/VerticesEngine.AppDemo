using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using VerticesEngine;
using VerticesEngine.Audio;
using VerticesEngine.ContentManagement;
using VerticesEngine.Graphics;

namespace VerticesEngine.AppDemo
{
    public enum GameContentPackType
    {
        BaseGame,
        Steampunk,
        TestBed
    }



    public class BaseMetricGameContentPack : TestContentPack
    {

        public override string ContentKey
        {
            get { return GameContentPackType.BaseGame.ToString(); }
        }


        protected override Texture2D LoadSpriteSheet()
        {
            vxGraphics.MainSpriteSheet = vxContentManager.Instance.Load<Texture2D>("Textures/Items/SpriteSheet");

            return vxGraphics.MainSpriteSheet;
        }

        public BaseMetricGameContentPack() : base("Base Game Content Pack")
        {

        }

        void AddSpriteFromSheet(object key, Rectangle source)
        {
            vxEntityRegister.EntitySpriteSheetRegister.Add(key.ToString(),
                                                              new vxEntitySpriteSheetDefinition(key.ToString(), this, source));

        }



        protected override void OnRegisterGameModes()
        {
            //RegisterGameMode(new BaseGamePuzzleMode());
            //RegisterGameMode(new BaseGameChaosMode());
        }



        protected override void LoadSoundEffects()
        {
            vxConsole.WriteLine("     Loading Sound Effects...");

            //vxAudioManager.LoadSoundEffect(Content, MetricSoundEffects.SE_Engine_Start, "sndfx/engine/engine_start");
            //vxAudioManager.LoadSoundEffect(Content, MetricSoundEffects.SE_Engine_Steady, "sndfx/engine/engine_steady");
            //vxAudioManager.LoadSoundEffect(Content, MetricSoundEffects.SE_Engine_DwnShft, "sndfx/engine/engine_dwnshift");

            //vxAudioManager.LoadSoundEffect(Content, MetricSoundEffects.SE_Missle_Woosh, "sndfx/wpns/msl/msl");

            //vxAudioManager.LoadSoundEffect(Content, MetricSoundEffects.SE_WeapongEquip_One, "sndfx/wpns/equip/equip1");
            //vxAudioManager.LoadSoundEffect(Content, MetricSoundEffects.SE_WeapongEquip_Two, "sndfx/wpns/equip/equip2");

            //vxAudioManager.LoadSoundEffect(Content, MetricSoundEffects.SE_Boost, "sndfx/boost/boost");
            //vxAudioManager.LoadSoundEffect(Content, MetricSoundEffects.SE_Explsn, "sndfx/explsn/explsn");


        }

        protected override void LoadMusic()
        {
            vxConsole.WriteLine("     Loading Music...");

            for (int i = 0; i < 5; i++)
            {
                // Load a Collection of the Songs
                //vxAudioManager.Music.Songs.Add(new vxSong(Content.Load<Song>("music/main_title"), "Chaotic", "RT Roe"));
                //vxAudioManager.Music.Songs.Add(new vxSong(Content.Load<Song>("music/Steam"), "Steam", "RT Roe"));
                //vxAudioManager.Music.Songs.Add(new vxSong(Content.Load<Song>("Music/3/file"), "Space", "Tom Roe"));
                //vxAudioManager.Music.Songs.Add(new vxSong(Content.Load<Song>("Music/4/file"), "Monkey Island Band", "Eric Matyas"));
                //vxAudioManager.Music.Songs.Add(new vxSong(Content.Load<Song>("Music/5/file"), "Sunday Morning", "Tom Roe"));
            }

        }


        protected override void OnRegisterLevelThemes()
        {

        }

        protected override void LoadTextures()
        {
            vxConsole.WriteLine("     Loading Textures...");

        }
    }
}
