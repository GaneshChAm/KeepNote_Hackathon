namespace KeepNote_Hackathon
{
    class Notes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }       
    }  

    class NotesData
    {
        List<Notes> list;
        public NotesData()
        {
            list = new List<Notes>()
            {
                new Notes{Id = 1234,Title ="Meeting",Description ="Meeting with Client @ 9 AM",Date=DateTime.Now},
                new Notes{Id = 6789,Title ="Pay Bills",Description ="Pay Electricity Bills",Date=(DateTime.Now)}
            };
        }

        public void AddNote(Notes notes)
        {
            list.Add(notes);
        }

        public int NoteId()
        {
            Random rand = new Random();
            int random = rand.Next(1000, 9999);
            return random;
        }

        public Notes GetNote(int id)
        {
            foreach (Notes c in list)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null;
        }

        public List<Notes> GetAllNotes()
        {
            return list;
        }

        public void UpdateNote(int id)
        {
            foreach (Notes c in list)
            {
                if (c.Id == id)
                {
                    Console.WriteLine("Enter Updated Notes Title");
                    c.Title = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter Updated Notes Description");
                    c.Description = Convert.ToString(Console.ReadLine());                  
                    Console.WriteLine("Notes Data Updated Successfully");
                }

            }
        }

        public bool DeleteNote(int id)
        {
            foreach (Notes c in list)
            {
                if (c.Id == id)
                {
                    list.Remove(c);
                    return true;
                }
            }
            return false;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            NotesData obj = new NotesData();
            string ret = "y";           
            do
            {
                try
                {
                    Console.WriteLine("Welcome to Take Note App");
                    Console.WriteLine("1. Create Note");
                    Console.WriteLine("2. View Note");
                    Console.WriteLine("3. ViewAllNotes");
                    Console.WriteLine("4. Update Note");
                    Console.WriteLine("5. Delete Note");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter the Notes Title");
                                string title = Console.ReadLine();

                                Console.WriteLine("Enter the Notes Description");
                                string des = Console.ReadLine();

                                int nid = obj.NoteId();
                                Console.WriteLine($"Your Note ID is {nid}");

                                obj.AddNote(new Notes() { Id = nid, Title = title, Description = des });
                                Console.WriteLine("Notes Added Successfully");
                                break;
                            }
                        case 2:
                            {
                                try
                                {
                                    Console.WriteLine("Enter the Note Id");
                                    int id = Convert.ToInt16(Console.ReadLine());
                                    Notes? c = obj.GetNote(id);
                                    if (c == null)
                                    {
                                        Console.WriteLine("Note ID does not exists!");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Data of NoteId:{c.Id} =");
                                        Console.WriteLine($"Title: {c.Title}\nDescription: {c.Description}\nDate&Time: {c.Date}");
                                    }
                                }
                                catch(FormatException)
                                {
                                    Console.WriteLine("Note ID is represent Only in Numbers");
                                }
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("ID \tTitle\t\tDescription\t\tDate&Time");
                                int count = 0;
                                foreach (var c in obj.GetAllNotes())
                                {
                                    Console.WriteLine($"{c.Id} \t{c.Title} \t{c.Description} \t{c.Date}");
                                    count = count + 1;

                                }
                                Console.WriteLine($"Total Notes= {count}");
                                break;
                            }
                        case 4:
                            {
                                try
                                {
                                    Console.WriteLine("Enter Note Id");
                                    int id = Convert.ToInt16(Console.ReadLine());
                                    obj.UpdateNote(id);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Note ID is represent Only in Numbers");
                                }
                                break;
                            }
                        case 5:
                            {
                                try
                                {
                                    Console.WriteLine("Enter Note Id");
                                    int id = Convert.ToInt16(Console.ReadLine());
                                    if (obj.DeleteNote(id))
                                    {
                                        Console.WriteLine("Note Data Deleted Successfully");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Note Id does not exist");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Note ID is represent Only in Numbers");
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong Choice Entered");
                                break;
                            }
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Choosing Options  Will be only in Numbers");
                }
                Console.WriteLine("Do you wish to continue? [y/n] ");
                ret = Console.ReadLine();
            } while (ret.ToLower() == "y");
        }
    }
}