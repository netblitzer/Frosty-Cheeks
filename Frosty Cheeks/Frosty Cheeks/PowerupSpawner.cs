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
        private Texture2D shortTex, longTex, rainbowTex;
        float spawnX;

        public PowerupSpawner(double _spawnWait, Texture2D _shortTex, Texture2D _longTex, Texture2D _rainbowTex, float _spawnX)
        {
            randoCalrission = new Random();
            spawnWait = _spawnWait;
            spawnX = _spawnX;
            lastSpawn = 0;
            shortTex = _shortTex;
            longTex = _longTex;
            rainbowTex = _rainbowTex;
        }
        public void Update(GameTime gameTime, float gameSpeed)
        {
            speed = gameSpeed;
            time = gameTime;
        }
        public Powerup TrySpawn()
        {
            int r = randoCalrission.Next(100);
            Powerup p;
            if(r < 33){
               p = Spawn(0);
            }else if(r >= 33 && r < 85){
               p = Spawn(1);
            }else{
               p = Spawn(2);
            }
            return p;
        }
        public Powerup Spawn(int type)//Input 0 to spawn a shorter powerup and 1 to spawn a longer powerup
        {
            lastSpawn = time.TotalGameTime.TotalSeconds;
            Powerup p;
            switch(type){
                case 0:
                    p = new ShorterPowerup(speed, shortTex, spawnX);
                    break;
                case 1:
                    p = new LongerPowerup(speed, longTex, spawnX);
                    break;
                case 2:
                    p = new RainbowPowerup(speed, rainbowTex, spawnX);
                    break;
                default:
                    p = new ShorterPowerup(speed, longTex, spawnX);
                    break;
            }
            spawnWait = randoCalrission.Next(5, (int)spawnWait);
            return p;
            
        }
        public bool IsTimeToSpawn()
        {
            return (time.TotalGameTime.TotalSeconds - lastSpawn > spawnWait);
        }
    }
}
