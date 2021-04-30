using System;
using System.Runtime.Serialization;

namespace WeatherMVC.Models
{
    //DataContract for Serializing Data - required to serve in JSON format
        [DataContract]
        public class DataModel
        {
            public DataModel(long? x, decimal? y)
            {
                this.x = x;
                this.Y = y;
            }
 
            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "x")]
            public Nullable<long> x = null;
 
            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "y")]
            public Nullable<decimal> Y = null;
            
        }
}