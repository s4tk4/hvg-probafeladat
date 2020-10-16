#Mi kell hozza?

Windows 7 tol felfel barmelyik microsoft windows operacios rendszer.
.Net framework 4.7.2
IIS Express
Visual Studio 2019

#Build, Deploy, Run - hogyan?
A project fileok kozott talalhato tobb Web.conf file, viszont a project config szinten a proba/proba/web.config <appSettings> ben talalhato dbdatafolder settinget nezi, az abban megadott erteknel hogy az adatokat hol tarolja illetve kezelje az alkalmazas.

JSON formatumban tarolodnak az adatok, jelen esetben a szamlak objektumai.
Az ott megadott eleresi utvonal ha nem letezik az alkalmazas automatikusan letre hozza.

IISExpress hasznalata nem kotelezo, csak a leggyorsabb megoldas volt jelen esetben, 

