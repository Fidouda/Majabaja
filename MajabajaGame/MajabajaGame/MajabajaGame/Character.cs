using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MajabajaGame
{
    static class Character
    {

        //On mettra ici la barre de vie

        static int actualTileID = 0;
        static int timeSinceLastFrame = 0;
        static int millisecondsPerFrame = 75;
 


        public static int nextTileID()
        {
            if (actualTileID < 64)
                return ++actualTileID;
            else
            {
                actualTileID = 0;
                return actualTileID;
            }
        }


      

        public static int runningLoop(GameTime gameTime) 
        {
           timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
           if (timeSinceLastFrame > millisecondsPerFrame)
           {
               timeSinceLastFrame = 0;

               if (actualTileID < 11)
                   return actualTileID++;
               else
               {
                   actualTileID = 4;
                   return actualTileID;
               }

           }
           else 
           {
               return actualTileID;
           }      
        }




    }
}
