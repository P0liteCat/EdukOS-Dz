/*Zadaca je sa zadnjeg slajda prezentacije strukturni obrasci: 

Koji je oblikovni obrazac prikladan za rješavanje zadatka danog u nastavku i 
u koju skupinu pripada?Navedite strukturu klasa te pripadajuće metode/atribute
koje biste koristili i njihove uloge:
_______________________________________________________________________________________________________________________

Razvijate sustav za upravljanje datotekama koji omogućuje organizaciju
i manipulaciju različitih vrsta datoteka u.    računarskom sustavu. 
Svaka datoteka može biti ili direktorij (folder) koji može sadržavati 
druge datoteke ili samo    konkretna datoteka.      
*/
//Može se napraviti koristeći kompozit koji pripada strukturnih obrazaca.


/*
File mi sadrži varijable za ime i za njihov sadržaj. Metoda za ispis sadržaja
mi je zasebna od ispisa imena zato što sam u filemanageru htio pri grananju
ispisati samo imena 
U folderu imam listu koja moze u sebe primiti jos foldera ili file-ove. Zbog toga
je potrebno korištenje apstrakcije u obliku IFileSystemObject*/ 


public interface IFileSystemObject
{
    void DisplayInfo();
}

public class File : IFileSystemObject
{
    private string name;
    private string content;

    public File(string name)
    {
        this.name = name;
        this.content = content;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"File: {name}");
        
    }

    public void DisplayContent()
    {
        Console.WriteLine($"It says:{content}");
    }
}


public class Directory : IFileSystemObject
{
    private string name;
    private List<IFileSystemObject> fileSystemObjects = new List<IFileSystemObject>();

    public Directory(string name)
    {
        this.name = name;
    }

    public void AddFileSystemObject(IFileSystemObject fileSystemObject)
    {
        fileSystemObjects.Add(fileSystemObject);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Directory: {name}");
        foreach (var fileSystemObject in fileSystemObjects)
        {
            fileSystemObject.DisplayInfo();
        }
    }
}


public class FileManager
{
    public IFileSystemObject fileSystemObject;

    public FileManager(IFileSystemObject fileSystemObject)
    {
        this.fileSystemObject = fileSystemObject;
    }

    public void DisplayFileSystemObjectInfo()
    {
        fileSystemObject.DisplayInfo();
    }
}


