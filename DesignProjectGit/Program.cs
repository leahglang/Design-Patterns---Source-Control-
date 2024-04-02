using DesignProjectGit;
using System;





User user1 = new("Avigail");
//User user2 = new("Malkah Yeudit");
//User user3 = new("Leah");

user1.AddBranch("Avigail's Branch");
//user2.AddBranch("Malkah Yeudit's Branch");

user1.GetBranch("Avigail's Branch").Add(new Folder("Avigail's Folder"));
user1.GetBranch("Avigail's Branch").Add(new MyFile("Avigail's file", "My name is Avigail"));


user1.GetBranch("Avigail's Branch").Add(new Branch("Avigail's Branch Seconde"));
user1.GetBranch("Avigail's Branch Seconde").Add(new Folder("Avigail's Folder Seconde"));
((Folder)user1.GetBranch("Avigail's Branch Seconde").Children["Avigail's Folder Seconde"]).Add(new MyFile("Avigail's File Seconde", "22222"));
user1.GetBranch("Avigail's Branch Seconde").Add(new MyFile("Avigail's File Theard", "2222221"));

user1.GetBranch("Avigail's Branch").Clone("Copy Of Avigail's Branch");

user1.print();
user1.GetBranch("Avigail's Branch").Added();



user1.GetBranch("Avigail's Branch").Commited();
user1.GetBranch("Avigail's Branch").Pull();
user1.GetBranch("Avigail's Branch").Push();
user1.GetBranch("Avigail's Branch").UnderReview();
user1.GetBranch("Avigail's Branch").ReadyToMerge();
user1.GetBranch("Avigail's Branch").Merged(new MyFile("Merged File", "I was merged"));


user1.GetBranch("Avigail's Branch").Print();
user1.GetBranch("Avigail's Branch").Undo();


MyFile comp = new MyFile("Merged File", "I want to be merged");
MyFile compo = new MyFile("Merged File", "I don't want to be merged");
compo.Added();
compo.Commited();
compo.Pull();
compo.Push();
compo.UnderReview();
compo.ReadyToMerge();
compo.Merged(comp);
comp.Merged(compo);


Folder folder = new Folder("folder1-undo");
folder.Add(compo);
comp.Merged(compo);
folder.Name = "undo";
folder.Undo();
