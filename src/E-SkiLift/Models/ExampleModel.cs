using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Models
{
    public class ExampleModel
    {
        private int _exampleIntProperty;
        private List<ExampleEntity> _exampleListProperty;

        public ExampleModel(int exampleIntProperty)
        {
            ExampleIntProperty = exampleIntProperty;
            ExampleListProperty = new List<ExampleEntity>();
            for (int i = 0; i < 1000; i++)
                ExampleListProperty.Add(new ExampleEntity("12:00 31.01.1996", i));
        }

        public int ExampleIntProperty { get => _exampleIntProperty; set => _exampleIntProperty = value; }
        public List<ExampleEntity> ExampleListProperty { get => _exampleListProperty; set => _exampleListProperty = value; }

        public class ExampleEntity
        {
            private String _date;
            private int _id;

            public ExampleEntity(string date, int id)
            {
                Date = date;
                Id = id;
            }

            public string Date { get => _date; set => _date = value; }
            public int Id { get => _id; set => _id = value; }
        }
    }
}
