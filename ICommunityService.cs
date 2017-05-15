using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommunityService" in both code and config file together.
[ServiceContract]
public interface ICommunityService
{
    [OperationContract]
    int Loginin(string user, string password);

    [OperationContract]
    bool RegisterUser(Person u);

    [OperationContract]
    List<PersonInfo> GetInfo();

    [OperationContract]

    PersonInfo GetInfo(string lastName, string firstName, string email, string password, string address);
}

[DataContract]
public class PersonInfo
{
    [DataMember]
    public string lastName { get; set; }
    [DataMember]
    public string firstName { get; set; }
    [DataMember]
    public string email { get; set; }
    [DataMember]
    public string password { get; set; }
    [DataMember]
    public string apartmentNumber { get; set; }

    internal static void Add(PersonInfo p1)
    {
        throw new NotImplementedException();
    }

    //[DataMember]
    // public string street { get; set; }
    [DataMember]
    public string city { get; set; }
    [DataMember]
    public string state { get; set; }
    [DataMember]
    public string zipCode { get; set; }
    [DataMember]
    public string homePhone { get; set; }
    [DataMember]
    public string workPhone { get; set; }
   

}
