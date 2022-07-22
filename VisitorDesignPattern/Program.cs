namespace VisitorDesignPattern
{
    public interface IVisitor
    {
        void Visit(IElement element);
    }
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }
    public class Kid : IElement
    {
        public string KidName { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        public Kid(string name)
        {
            KidName = name;
        }
    }
    public class Doctor : IVisitor
    {
        public string Name { get; set; }

        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Console.WriteLine($"Doctor: {Name} did the health checkup of the child: {kid.KidName}");
        }
        public Doctor(string name)
        {
            Name = name;
        }
    }
    class Salesman : IVisitor
    {
        public string Name { get; set; }
        public Salesman(string name)
        {
            Name = name;
        }
        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Console.WriteLine($"Salesman: {Name} gave the school bag to the child: {kid.KidName}");
        }
    }
    public class School
    {
        private static List<IElement> elements;
        static School()
        {
            elements = new List<IElement>
            {
                new Kid("Leyla"),
                new Kid("Nihad"),
                new Kid("Ferman")
            };
        }
        public void PerformOperation(IVisitor visitor)
        {
            foreach (var kid in elements)
            {
                kid.Accept(visitor);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            School school = new();
            var visitor1 = new Doctor("James");
            school.PerformOperation(visitor1);
            Console.WriteLine();
            var visitor2 = new Salesman("John");
            school.PerformOperation(visitor2);
            Console.Read();
        }
    }
}