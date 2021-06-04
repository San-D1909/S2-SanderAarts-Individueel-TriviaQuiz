using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager.Data;

namespace BusinessManager.Business
{
    public class RegisterContainer
    {
        public RegisterRepository registerRepository = new RegisterRepository();
        public RegisterRepository RegisterRepository
        {
            get
            {
                return registerRepository;
            }
            set
            {
                registerRepository = value;
            }
        }
        public bool InsertUser( UserDTO userDTO)
        {
            if (RegisterRepository.InsertUser( userDTO.FirstName,userDTO.LastName,userDTO.Email, userDTO.Password,userDTO.BirthDay))
            {
                return true;
            }
            return false;
        }
    }
}
