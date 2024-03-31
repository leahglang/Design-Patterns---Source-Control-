using DesignProjectGit;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


User user1 = new("Avigail");
User user2 = new("Malkah Yeudit");
User user3 = new("Leah");

user1.AddBranch("Avigail's Branch");
//user2.AddBranch("Malkah Yeudit's Branch");

user1.GetBranch("Avigail's Branch").Add(new Folder("Avigail's Folder"));
user1.GetBranch("Avigail's Branch").Add(new MyFile("Avigail's file", "My name is Avigail"));


user1.GetBranch("Avigail's Branch").Add(new Branch("Avigail's Branch Seconde"));
user1.GetBranch("Avigail's Branch Seconde").Add(new Folder("Avigail's Folder Seconde"));
((Folder)user1.GetBranch("Avigail's Branch Seconde").Children["Avigail's Folder Seconde"]).Add(new MyFile("Avigail's File Seconde","22222"));
user1.GetBranch("Avigail's Branch Seconde").Add(new MyFile("Avigail's File Theard", "2222221"));

((Folder)user1.GetBranch("Avigail's Branch").Children["Avigail's File Seconde"]).Children["Avigail's File Theard"].Merge(new MyFile("Merged File", "I was merged"));


user1.GetBranch("Avigail's Branch").Clone("Copy Of Avigail's Branch");


user1.print();
