using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommunityService" in code, svc and config file together.
public class CommunityService : ICommunityService
{
    Community_AssistEntities db = new Community_AssistEntities();

    public List<PersonInfo> GetInfo()
    {
        var per = from b in db.People
                  select new
                  {
                      b.PersonLastName,
                      b.PersonFirstName,
                      b.PersonEmail,
                      b.PersonPassWord,
                      b.PersonAddresses,

                  };
        List<PersonInfo> info = new List<PersonInfo>();
        foreach (Person pe in per)
        {
            PersonInfo p1 = new PersonInfo();
            p1.lastName = pe.PersonLastName;
            p1.firstName = pe.PersonFirstName;
            p1.email = pe.PersonEmail;

            PersonInfo.Add(p1);

        }
        return info;
        
    }
    
   

    public PersonInfo GetInfo(string infoo)
    {
        var gin = (from b in db.People from a in b.PersonKey where a.person.Equals(infoo) select b);
        return gin;
    }

    public int Loginin(string user, string password)
    {
        int key = 0;
        int result = db.usp_Login(user, password);
        if (result != -1)
        {
            var userKey = (from k in db.People where k.PersonEmail.Equals(user) select k.PersonKey).FirstOrDefault();
            key = (int)userKey;
        }
        return key;
    }

    public bool RegisterUser(Person u)
    {
        bool result = true;
        int use = db.usp_Register (u.PersonLastName, u.PersonFirstName, u.PersonEmail, u.PersonPassWord, u.PersonAddresses);

        return result;

    }
}
