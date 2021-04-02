using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.FolderExceptionHandler
{
    public static class Responses
    {
        public static string DefaultResponse = @"
             <!DOCTYPE html>
             <html lang=""en"">
                 <head>
                    <title>Error</title>
                 </head>
                 <body>
                     <h2 align=""center"">Page NOT Found {0}</h2>
                     <hr>
                     <h3 align=""center"">
                     You can go back to the <a href=""/"">homepage</a> and try again
                     </h3>
                 </body>
             </html>";
    }
}
