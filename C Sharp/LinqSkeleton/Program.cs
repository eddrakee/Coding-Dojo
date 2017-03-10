using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
                Artist vernon = Artists.Where(artist => artist.Hometown == "Mount Vernon").Single();
                System.Console.WriteLine("- Rapper from Mount Vernon -");
                System.Console.WriteLine(vernon.ArtistName);
            //Who is the youngest artist in our collection of artists?
                Artist youngest = Artists.OrderBy(artist => artist.Age).First();
                System.Console.WriteLine("- Youngest Rapper -");
                System.Console.WriteLine(youngest.ArtistName);

            //Display all artists with 'William' somewhere in their real name
                List<Artist> william = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
                System.Console.WriteLine("- Rappers Named William -");
                
                foreach(var artist in william){
                    System.Console.WriteLine(artist.ArtistName + " aka " + artist.RealName);
                }
            // Display all groups with names less than 8 characters in length.
                List<Group> eight = Groups.Where(group => group.GroupName.Length < 8).ToList();
                System.Console.WriteLine("- Rap Groups With Less Than 8 Characters -");
                    foreach(var group in eight){
                        System.Console.WriteLine(group.GroupName);
                    }
            //Display the 3 oldest artist from Atlanta
                List<Artist> oldest = Artists.Where(artist => artist.Hometown == "Atlanta")
                    .OrderByDescending(artist => artist.Age)
                    .Take(3)
                    .ToList();
                System.Console.WriteLine("- Top 3 Oldest Rappers -");
                foreach (var artist in oldest){
                    System.Console.WriteLine(artist.ArtistName + " is " + artist.Age + " years old!");
                }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
                List<string> nonyc = Artists
                    .Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => {artist.Group = group; return artist;})
                    .Where(artist => (artist.Hometown != "New York City" && artist.Group != null))
                    .Select(artist => artist.Group.GroupName)
                    // Distinct makes sure there are no duplicates
                    .Distinct()
                    .ToList();
                System.Console.WriteLine("- Groups With Artists Who Are Not From NYC -");
                foreach(var group in nonyc){
                    System.Console.WriteLine(group);
                }
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            Group wutang = Groups.Where(group => group.GroupName == "Wu-Tang Clan")
                .GroupJoin(Artists,
                    group => group.Id,
                    artist => artist.GroupId,
                    (group, artists) => {group.Members = artists.ToList(); return group;})
                .Single();
            System.Console.WriteLine("- Group Members of Wu-Tang Clan -");
            foreach(var artist in wutang.Members){
                System.Console.WriteLine(artist.ArtistName);
            }
        }
    }
}
