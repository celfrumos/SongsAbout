REM C:\Ruby\bin\setrbvars.bat
#!/usr/bin/env ruby

cd $(ProjectDir)\Content\SASS
sass site.scss ../Site.css
sass themes.scss ../themes.css 
@ECHO ON
echo Done

pause