using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ToDoListManager : IToDoListService
    {
        IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public void TAdd(ToDoList t)
        {
            _toDoListDal.Insert(t);
        }

        public void TDelete(ToDoList t)
        {
            _toDoListDal.Delete(t);
        }

        public ToDoList TGetByID(int id)
        {
            return _toDoListDal.GetByID(id);
        }

        public List<ToDoList> TGetList()
        {
            return _toDoListDal.GetList();
        }

        public void TUpdate(ToDoList t)
        {
            _toDoListDal.Update(t);
        }
    }
}
