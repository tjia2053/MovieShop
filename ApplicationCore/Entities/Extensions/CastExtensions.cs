using System;

namespace ApplicationCore.Entities.Extensions
{
	public static class CastExtensions
	{
        public static string GetGender(this Cast cast)
        {
            switch (int.Parse(cast.Gender))
            {
                case 1: return "Female";
                case 2: return "Male";
                case 3: return "Other";

            }

            return "Other";
        }
    }
}

