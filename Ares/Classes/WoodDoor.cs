﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.Audio;
using Lidgren.Network;

namespace Ares
{
    public class WoodDoor : Door
    {
        public WoodDoor(Vector2i position, bool leftFacing)
            : base(position, leftFacing)
        {
        }

        public override void Update()
        {
            open = false;
            if (!locked)
            {
                for (int i = 0; i < Game.internalGame.map.Actors.Count; i++)
                {
                    Actor iActor = Game.internalGame.map.Actors[i]; // This will need to refer to NPCs as well
                        if (Helper.Distance(iActor.IsoPosition, this.IsoCoords) < 35)
                        {
                            open = true;
                        }

                }

                //if (Helper.Distance(Game.internalGame.map.ClientPlayer.IsoPosition, this.IsoCoords) < 35)
                //{
                //    open = true;
                //}

            }
            else
            {
                open = false;
            }



            //Console.WriteLine(Helper.Distance(Game.internalGame.map.ClientPlayer.IsoPosition, this.IsoCoords + new Vector2i(20, 53)));

            base.Update();
        }

        public override void Draw(float drawLayer)
        {
            var tOrigin = new Vector2f(32f, 47f);
            var tRot = 0f;
            Color tCol = Color.White;
            if (IsoCoords.X / 32 % 2 == 0)
                tCol = new Color(190, 190, 190);
            int tFacing = LeftFacing ? 1 : -1;
            int tOpenFacing = open ? -1 : 1;
            Texture woodDoor = Content.GetTexture("wall/door/door2.png");
            Render.Draw(woodDoor, IsoCoords.ToF(), tCol, tOrigin, tFacing * tOpenFacing, tRot, drawLayer);

            base.Draw(drawLayer);
        }
    }
}
