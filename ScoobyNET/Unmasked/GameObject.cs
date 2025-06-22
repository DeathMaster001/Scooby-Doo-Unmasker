using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoobyNET.Unmasked
{
    internal class GameObject
    {
        float x, y, z;
        uint baseaddress;
        objectType gameObjectType;

        public GameObject(uint address, objectType gameObj)
        {
            this.baseaddress = address;
            this.gameObjectType = gameObj;
            this.getPosition();
        }

        public void getPosition()
        {
            float[] Position = Memory.getObjectPosition(this.baseaddress);
            this.x = Position[0];
            this.y = Position[1];
            this.z = Position[2];
        }
        public void setPosition(float newx, float newy, float newz)
        {
            Memory.setObjectPosition(this.baseaddress, newx, newy, newz);
            this.getPosition();
        }
    }

    enum objectType
    {
        clue = 0,
        food,
        mubber,
        scoobySnacks,
        traps,
        costumeCoins
    }
}
