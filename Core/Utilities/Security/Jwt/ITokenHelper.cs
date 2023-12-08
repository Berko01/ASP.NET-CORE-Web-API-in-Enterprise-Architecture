using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Microsoft.Identity.Client;

namespace Core.Utilities.Security.Jwt
{
	//Javascriptte objeler birini referans edebilir. Ancak .NET'de bu mümkün değil. Mesela Entity şuan Core'u kullanıyor. Core entity kullanamaz.
	public interface ITokenHelper
	{
		AccessToken CreateToken(User user, List<OperationClaim> operationClaims);

	}
}
