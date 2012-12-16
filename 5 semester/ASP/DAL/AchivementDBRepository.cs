using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace DAL
{
    public class AchivementDBRepository : IAchivementDbRepository
    {
        private EntityContext context;

        public AchivementDBRepository()
        {
            context = new EntityContext();
        }

        public void Create(Achivement achivement)
        {
            context.Achivements.Add(achivement);
            context.SaveChanges();
        }

        public IList<Achivement> Read()
        {
            return context.Achivements.ToList();
        }

        public IList<Achivement> Read(User user)
        {
            var Info = context.AchivementInfo.Where(a => a.User == user);
            IList<Achivement> achivements = new List<Achivement>(); 
            foreach (AchivementInfo info in Info)
                achivements.Add(context.Achivements.Where(a => a.ID == info.AchivementId).First());

            return achivements;
        }

        public bool Update(Achivement achivement)
        {
            Achivement ach = context.Achivements.Where(a => a.ID == achivement.ID).First();
            if (ach != null)
            {
                ach = achivement;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Achivement achivement)
        {
            context.Achivements.Remove(achivement);
            context.SaveChanges();

            return true;
        }

        public bool Delete()
        {
            foreach (Achivement ach in context.Achivements)
                context.Achivements.Remove(ach);

            context.SaveChanges();

            return true;
        }
    }
}
