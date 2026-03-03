using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.BLL.SERVICES
{
    public interface IAiService
    {
        Task<string> AskAsync(string prompt);
    }
}
