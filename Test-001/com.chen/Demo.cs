namespace Test_001.com.chen
{
    public class Demo
    {
        private int age;

        private int name;

        private int sex;

        public Demo(int age, int name, int sex)
        {
            this.age = age;
            this.name = name;
            this.sex = sex;
        }

        public int GetAge()
        {
            return this.age;
        }

        public int GetName()
        {
            return this.name;
        }
    }
}