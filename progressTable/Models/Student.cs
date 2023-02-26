namespace progressTable.Models
{
    public class Student
    {
        private string _name = "";
        private float _averageRating = 0;
        private ushort[] _ratings = {0, 0, 0, 0};

        public Student(string Name)
        {
            this._name = Name;
        }
        
        public string Name 
        { 
            get => _name; 
            set => _name = value; 
        }
        public ushort Visual
        {
            get => _ratings[0];
            set => _ratings[0] = value;
        }
        public ushort Architecture
        {
            get => _ratings[1];
            set => _ratings[1] = value;
        }
        public ushort Networks
        {
            get => _ratings[2];
            set => _ratings[2] = value;
        }
        public float Average_Rating
        {
            get
            {
                _averageRating = 0;
                foreach (ushort rating in _ratings)
                {
                    _averageRating += rating;
                }
                return _averageRating /= _ratings.Length;
            }
        }
    }
}

