namespace LabyFights
{
    public class Weapon
    {
        int damage;
        public Weapon(int damage)
        {
            this.damage = damage;
        }
        public int Damage
        {
            get
            {
                return damage;
            }

            set
            {
                damage = value;
            }
        }
        public void UseWeapon()
        {
            if(damage > 0)
            {
                damage -= 1;
            }
        }
    }
}