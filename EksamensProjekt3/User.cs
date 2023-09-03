using System;

namespace EksamensProjekt3
{
    public class User
    {
        private int _id;
        private string _email;
        private string _password;
        private string _name;
        private string _address;
        private int _postalcode;
        private bool _admin;

        public User()
        {
            //_id = User.idnr;
            //User.idnr++;
        }

        public User(int id, bool admin, string email, string password, string name, string address, int postalcode)
        {
            _id = id;
            // User.idnr++;
            _admin = admin;
            _email = email;
            _password = password;
            _name = name;
            _address = address;
            _postalcode = postalcode;

        }

        public int Id
        {
            get => _id;
            set
            {
                //if (value == 0 && _id==0) throw new ArgumentException();
                _id = value;
            }
        }
        public bool Admin
        {
            get => _admin;
            private set
            {
                if (_admin == false)
                {
                    _admin = value;
                }
                else
                {
                    _admin = true;
                }
                    
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                //if (!value.Contains("@")|| !value.EndsWith(".com") || !value.EndsWith(".dk") || !value.EndsWith(".net") || !value.EndsWith(".org")) throw new ArgumentException();
                _email = value;
            }
        }


        public string Password
        {
            get => _password;
            set
            {
                if (value == null) throw new ArgumentNullException();
                if (value.Length < 4) throw new ArgumentOutOfRangeException();
                _password = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
            }
        }
        public int Postalcode
        {
            get => _postalcode;
            set
            {
                _postalcode = value;
            }
        }
        //public int Price
        //{
        //    get => _price;
        //    set
        //    {
        //        if (value == 0 || value < 0) throw new ArgumentOutOfRangeException();

        //        _price = value;
        //    }
        //}
        //public int ShirtNumber
        //{
        //    get => _shirtNumber;
        //    set
        //    {
        //        if (value >= 1 && value <= 100)
        //        _shirtNumber = value;
        //        else { throw new ArgumentOutOfRangeException(); }
        //    }
        //}


    }
}
