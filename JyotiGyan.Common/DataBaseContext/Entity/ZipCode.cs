using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JyotiGyan.Common.DataBaseContext.Entity;

[Table("zipcodes")]
public class ZipCode
{
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    public string Code { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("city")]
    public string City { get; set; }

    [Column("area_code")]
    public string AreaCode { get; set; }

    [Column("lat")]
    public float Lat { get; set; }

    [Column("lon")]
    public float Lon { get; set; }

    [Column("accuracy")]
    public string Accuracy { get; set; }

}

[Table("zipcodes_temp1")]
public class ZipCodeTemp //: ZipCode
{
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    public string Code { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("city")]
    public string City { get; set; }

    [Column("area_code")]
    public string AreaCode { get; set; }

    [Column("lat")]
    public float Lat { get; set; }

    [Column("lon")]
    public float Lon { get; set; }

    [Column("accuracy")]
    public string Accuracy { get; set; }
}
