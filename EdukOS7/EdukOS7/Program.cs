using System.Reflection.Metadata.Ecma335;

namespace Zadatak1
{

    public class Event
    {
        public string Type { get; set; }

        public Event(string Type)
        {
            this.Type = Type;
        }
    }
    public interface IEventHandler
    {
        public void SetSuccessor (IEventHandler handler);
        public void HandleEvent(Event movementevent);
    }

    public class BaseHandler : IEventHandler
    {
        protected IEventHandler successor;
        private IEventHandler last;

        public virtual void HandleEvent(Event movementevent)
        {
            if(successor != null)
            {
                successor.HandleEvent(movementevent);
            }
        }

        public void SetSuccessor(IEventHandler handler)
        {
            if(successor == null)
            {
                successor = handler;
                last = successor;
            }
            else
            {
                last.SetSuccessor(handler);
                last = handler;
            }
        }            
    }

    public class DrivingHandler : BaseHandler
    {
        public override void HandleEvent(Event movementevent)
            {
            if(movementevent.Type == "InCar")
            {
                Console.WriteLine("DrivingHandler handled Driving Physics");
            }
            else
            {
                Console.WriteLine("DrivingHandler passed the event to the next handler");
                successor.HandleEvent(movementevent);
            }
        }

    }

    public class FlyingHandler : BaseHandler
    {
        public override void HandleEvent(Event movementevent)
        {
            if (movementevent.Type == "InPlane")
            {
                Console.WriteLine("DrivingHandler handled Flying Physics");
            }
            else
            {
                Console.WriteLine("FlyingHandler passed the event to the next handler");
                successor.HandleEvent(movementevent);
            }
        }

    }


    public class Character
    {
        public Character()
        {
            IEventHandler drivingHandler = new DrivingHandler();
            IEventHandler flyingHandler = new FlyingHandler();
            IEventHandler baseHandler = new BaseHandler();

            baseHandler.SetSuccessor(drivingHandler);
            drivingHandler.SetSuccessor(flyingHandler);

            Event carEvent = new Event("InCar");
            Event planeEvent = new Event("InPlane");
            Event otherEvent = new Event("SomeOtherEvent");

            drivingHandler.HandleEvent(carEvent);
            drivingHandler.HandleEvent(planeEvent);
            drivingHandler.HandleEvent(otherEvent);
        }
    }



}



namespace Zadatak2
{
    public class Subject
    {
        public string Name;
        public int Ects;

        public Subject(string name, int ects)
        {
            Name = name;
            Ects = ects;
        }
    }

    public interface IIterator
    {
        public Subject GetNext();
        public bool HasNext();
    }

    public interface IIteratorCollection
    {
        public IIterator CreateIterator();
    }

    public class SubjectCollection : IIteratorCollection
    {
        public List<Subject> subjects;

        public SubjectCollection()
        {
            subjects= new List<Subject>();
        }

        public IIterator CreateIterator()
        {
            return new SubjectIterator(this);
        }
        public Subject GetSubject(int index)
        {
            return subjects[index];
        }
        public int Count()
        {
            return subjects.Count;
        }
    }

    public class SubjectIterator : IIterator
    {
        SubjectCollection subjectCollection;
        int Current;

        public SubjectIterator(SubjectCollection subjectCollection)
        {
            this.subjectCollection = subjectCollection;
            Current = 0;
        }

        public Subject GetNext()
        {
            Subject subject= subjectCollection.GetSubject(Current);
            Current++;
            return subject;
        }

        public bool HasNext()
        {
            return Current >= subjectCollection.Count();
        }
    }

    public static class ClientCode
    {
        public static void Main()
        {
            SubjectCollection subjectCollection = new SubjectCollection();
            subjectCollection.subjects.Add(new Subject("Digitalna Elektronika", 999));
            subjectCollection.subjects.Add(new Subject("Signali i Sustavi", 999));
            subjectCollection.subjects.Add(new Subject("RPPOON", 998));

           
            SubjectIterator subjectiterator = (SubjectIterator)subjectCollection.CreateIterator();


            while (!subjectiterator.HasNext())
            {
                
                Subject currentSubject = subjectiterator.GetNext();
                Console.WriteLine($"Subject: {currentSubject.Name}, ECTS: {currentSubject.Ects}");
            }

            
        }
    }
}
