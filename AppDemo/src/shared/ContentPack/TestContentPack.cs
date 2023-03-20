

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using VerticesEngine;
using VerticesEngine.Audio;
using VerticesEngine.Plugins;

namespace VerticesEngine.AppDemo
{
    /// <summary>
    /// Chaotic Workshop content pack which holds level and entity definitions along with Texture, Sound Effect
    /// and Music Data. Inherit this to create your own Content Packs.
    /// </summary>
    public class TestContentPack : vxIPlugin
    {
        public string Name
        {
            get { return _name; }
        }
        string _name = "name";

        /// <summary>
        /// The description for this content pack
        /// </summary>
        public virtual string Description
        {
            get { return "Content Pack Description"; }
        }

        public virtual vxPluginType PluginType
        {
            get { return vxPluginType.Mod; }
        }

        public virtual string ID
        {
            get { return ContentKey; }
        }

        /// <summary>
        /// Each content pack must have it's own main sprite sheet
        /// </summary>
        public Texture2D MainSpriteSheet
        {
            get
            {
                return _contentPackSpriteSheet;
            }
        }
        Texture2D _contentPackSpriteSheet;


        /// <summary>
        /// A unique key for this Content Pack. 
        /// </summary>
        public virtual string ContentKey
        {
            get { throw new Exception("Content Pack Key Not set for '" + Name + "'. Override Property 'ContentPackKey' to set unique Content Pack ID Key."); }
        }

        public bool IsLoaded => true;


        public TestContentPack(string ContentPackName)
        {
            _name = ContentPackName;
        }



        public virtual void Initialise()
        {

        }

        protected virtual Texture2D LoadSpriteSheet()
        {
            throw new Exception("No Sprite Sheet found for Content Pack '" + Name + "'. Override Property 'LoadSpriteSheet'.");
        }


        IEnumerator vxIPlugin.LoadContent()
        {

        //}
        //public virtual void LoadContent()
        //{
            Console.WriteLine("[PLUGIN] - Loading Content " + Name);

            LoadMusic();
            yield return null;

            LoadSoundEffects();
            yield return null;

            LoadTextures();
            yield return null;

            OnRegisterCustomShipParts();
            yield return null;

            // regoster level themes
            OnRegisterLevelThemes();
            yield return null;

            // register game modes
            OnRegisterGameModes();
            yield return null;

            //Start the Music, only in the release version though
            //#if !DEBUG
            //Microsoft.Xna.Framework.Media.MediaPlayer.Play(vxAudioManager.Music.Songs[0].Song);
            //Microsoft.Xna.Framework.Media.MediaPlayer.IsRepeating = true;
            //Microsoft.Xna.Framework.Media.MediaPlayer.Volume = vxAudioManager.MusicVolume;

            //#endif
        }

        /// <summary>
        /// Register Level Themes
        /// </summary>
        protected virtual void OnRegisterLevelThemes() { }

        /// <summary>
        /// Register Game Modes
        /// </summary>
        protected virtual void OnRegisterGameModes() { }

        /// <summary>
        /// Registers Custom Ship Parts
        /// </summary>
        protected virtual void OnRegisterCustomShipParts() { }

        /// <summary>
        /// Registers the new category with Metric. This is called at game launch.
        /// </summary>
        /// <param name="category">Category.</param>
        /// <param name="iconLocation">Icon location.</param>
        /// <param name="color">Color.</param>
        protected void RegisterNewCategory(string categoryName, object categoryKey, Rectangle iconLocation, Color color)
        {

        }



        protected virtual void LoadMusic() { }

        protected virtual void LoadTextures() { }

        protected virtual void LoadSoundEffects() { }

    }
}
