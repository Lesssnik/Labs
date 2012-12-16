using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using DAL;

namespace BLL
{
    public class AchivementComponents
    {
        private AchivementDBRepository Db;

        public AchivementComponents()
        {
            Db = new AchivementDBRepository();
        }

        public IList<Achivement> GetAchivements()
        {
            return Db.Read();
        }

        public IList<Achivement> GetUserAchivements(User user)
        {
            return Db.Read(user);
        }

        public void AddAchivement(Achivement achivement)
        {
            Db.Create(achivement);
        }

        public bool UpdateAchivement(Achivement achivement)
        {
            return Db.Update(achivement);
        }

        public bool DeleteAchivement(Achivement achivement)
        {
            return Db.Delete(achivement);
        }

        public bool DeleteAchivements()
        {
            return Db.Delete();
        }
    }
}
