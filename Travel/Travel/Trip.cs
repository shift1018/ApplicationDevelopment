using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel
{
    public class Trip
    {
        public Trip() { }
        

        public Trip(string destination, string travellerName, string travellerPassport, DateTime departureDate, DateTime returnDate)
        {
            Destination = destination;
            TravellerName = travellerName;
            TravellerPassport = travellerPassport;
            DepartureDate = departureDate;
            ReturnDate = returnDate;
        }

        public int Id { get; set; }

        private string _destination;

        [Required]
        [StringLength(30)]
        public string Destination

        {
            get
            {
                return _destination;
            }
            set
            {

                if (value.Length < 2 || value.Length > 30)
                {
                    throw new ArgumentException("Maximum task size exceeded: must be up to 30 characters long");
                }
                _destination = value;
            }
        }



        private string _travellerName;

        [Required]
        [StringLength(30)]
        public string TravellerName
        {
            get
            {
                return _travellerName;
            }
            set
            {

                if (value.Length < 2 || value.Length > 30)
                {
                    throw new ArgumentException("Maximum task size exceeded: must be up to 30 characters long");
                }
                _travellerName = value;
            }
        }


        private string _travellerPassport;

        [Required]
        [StringLength(8)]
        public string TravellerPassport
        {
            get
            {
                return _travellerPassport;
            }
            set
            {
                string str1 = value.Substring(0, 1);
                string str2 = value.Substring(2);
                int n;

                if (int.TryParse(str1, out n))
                {
                    throw new ArgumentException("The passport should begin with two characters");//????  1 character 1 num
                }
                if (!int.TryParse(str2, out n))
                {
                    throw new ArgumentException("The passport should end with six characters");
                }

                _travellerPassport = value;
            }
        }


        private DateTime _departureDate;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DepartureDate
        {
            get
            {
                return _departureDate;
            }
            set
            {
                if (value < DateTime.Today)
                {
                    throw new ArgumentException("The date should be after today");
                }
                _departureDate = value;
            }

        }


        private DateTime _returnDate;

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReturnDate
        {
            get
            {
                return _returnDate;
            }
            set
            {
                if (value < DepartureDate)
                {
                    throw new ArgumentException("The date should be after departureDate");
                }
                _returnDate = value;
            }

        }



    }
}
