using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//abstract -> I can't be instanced , but I can be Inherited From!!!!
public abstract class BaseRepo
{
    //Idea is to make C.R.U.D operations 1 time and use it w/ all of the inheriting repos!!!
    protected readonly List<IIdentifiable> _repo = new List<IIdentifiable>();
    protected int _count = 0;

    //? add an item to the database Create:
    public bool AddToDatabase(IIdentifiable item)
    {
        if (item != null)
        {
            _count++;
            item.ID = _count;
            _repo.Add(item);
            return true;
        }
        return true;
    }

    //? Read
    public IIdentifiable GetItem(int id)
    {
        if (id < 1)
            return null;

        foreach (var item in _repo)
        {
            if (item.ID == id)
                return item;
        }
        return null;
    }

    //? Get All Read:
    public List<IIdentifiable> GetAllItems()
    {
        return _repo;
    }

    //? Delete
    public bool DeleteItem(int id)
    {
        if (id < 1)
            return false;

        foreach (var item in _repo)

            if (item.ID == id)
                return _repo.Remove(item);

        return false;


        //  foreach (var item in _repo)
        //     return (item.ID == id) ? _repo.Remove(item) : false;
        // return false;
    }
}
