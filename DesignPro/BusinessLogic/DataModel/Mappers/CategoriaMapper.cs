using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;
using Common.DataTransferObjects;

namespace BusinessLogic.DataModel.Mappers
{
    class CategoriaMapper
    {
        public DTOCategoria MapToDTOCategoria(Categoria cat)
        {
            if(cat == null)
            {
                return null;
            }
            DTOCategoria DTOCat = new DTOCategoria()
            {
                Nombre = cat.Nombre
            };
            return DTOCat;
        }

        public Categoria MapFromDTOCategoria(DTOCategoria DTOCat)
        {
            if(DTOCat == null)
            {
                return null;
            }
            Categoria cat = new Categoria()
            {
                Nombre = DTOCat.Nombre
            };
            return cat;
        }
    }
}
