using DoctorWho.Domain;
using System;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeCompanionsRepository
    {
        public static void AddCompanionToEpisode(Companion Companion, int EpisodeId)
        {
            if (Companion == null) throw new ArgumentNullException("Invalid input! Please provide a companion instance that is NOT NULL...");
            var episode = DoctorWhoCoreDbContext._context.Episodes.Find(EpisodeId);
            if (episode != null)
            {
                episode.EpisodeCompanions.Add(new EpisodeCompanion { CompanionId = Companion.CompanionId, EpisodeId = EpisodeId });
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            else throw new InvalidOperationException("No episodes with the provided Id exist in the database!");
        }
    }
}