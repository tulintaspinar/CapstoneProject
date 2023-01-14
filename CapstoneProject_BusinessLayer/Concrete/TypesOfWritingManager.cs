using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DataAccessLayer.Abstract;
using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.Concrete
{
    public class TypesOfWritingManager : ITypesOfWritingService
    {
        ITypesOfWritingDal _typesOfWritingDal;

        public TypesOfWritingManager(ITypesOfWritingDal typesOfWritingDal)
        {
            _typesOfWritingDal = typesOfWritingDal;
        }

        public void TAdd(TypesOfWriting t)
        {
            _typesOfWritingDal.Insert(t);
        }

        public void TDelete(TypesOfWriting t)
        {
            _typesOfWritingDal.Delete(t);
        }

        public TypesOfWriting TGetById(int id)
        {
            return _typesOfWritingDal.GetById(id);
        }

        public List<TypesOfWriting> TGetList()
        {
            return _typesOfWritingDal.GetList();
        }

        public void TUpdate(TypesOfWriting t)
        {
            _typesOfWritingDal.Update(t);
        }
    }
}
