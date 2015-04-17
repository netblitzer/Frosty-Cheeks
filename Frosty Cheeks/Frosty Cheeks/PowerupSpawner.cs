#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Frosty_Cheeks
{
    class PowerupSpawner
    {
        private double spawnWait;//How many millis to wait between spawns (random range)
        private Random randoCalrission;
        private GameTime time;
        private double lastSpawn;
        private float speed;
        private Texture2D shortTex, longTex;

        public PowerupSpawner(double _spawnWait, Texture2D _shortTex, Texture2D _longTex)
        {
            randoCalrission = new Random();
            spawnWait = _spawnWait;
            lastSpawn = 0;
            shortTex = _shortTex;
            longTex = _longTex;
        }
        public void Update(GameTime gameTime, float gameSpeed)
        {
            speed = gameSpeed;
            time = gameTime;
        }
        public Powerup Spawn()
        {
            if(randoCalrission.Next(10) >= 5){
                return(Spawn(0));
            }
            else
            {
                return(Spawn(1));
            }
        }
        public Powerup Spawn(int type)//Input 0 to spawn a shorter powerup and 1 to spawn a longer powerup
        {
            lastSpawn = time.ElapsedGameTime.TotalSeconds;
            Powerup p;
            switch(type){
                case 0:
                    p = new ShorterPowerup(speed, shortTex);
                    break;
                case 1:
                    p = new LongerPowerup(speed, longTex);
                    break;
                default:
                    p = new ShorterPowerup(speed, longTex);
                    break;
            }
            return p;
        }
        public bool IsTimeToSpawn()
        {
            return ((lastSpawn + spawnWait) > time.ElapsedGameTime.TotalSeconds);
        }
    }
}
