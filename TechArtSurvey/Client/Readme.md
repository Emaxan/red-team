### To install: ###
1. in console open directory of package.json file.
2. type "npm install". It will install all npm modules from package.json settings.
3. if there are errors like 'cant find module', type "npm install this-module-name --save".

### For developing, when you make some changes in project: ###
1. Open the directory in console.
2. Type "npm start". It will start webpack-dev-server on localhost:3000 (can be changed in config-file). 

For what: when you change the project (add some changes in js, css, html and etc), you can see results of your changes. If the server is started, it would watch for your changes and make auto-recompiling.

### Commands: ###
* "npm run prod" - building the production version of the project
* "npm start" - building and starting dev-server in browser
* "npm install module-name --save" - installing module into the project

### Structure: ###
* conf - all configurations of the project
* src/{yourModuleName} - a folder which will contain all of your files for the module you're developing now. It also may contain such sub-folders as "images" and etc. Your module should have one container and zero or more components. All components should be located in 'components' folder.

Root.jsx - entry point for webpack

Server will return built html file, so you don't need to find it and open by yourselves.

### Most frequent errors: ###
* Errors of parsing (showed in console). <p>Reason: These errors will appear if you have any mistakes in webpack configs. Loaders (for example, css loaders) could be added wrongly. Most often it happens because of adding loaders by tutorials for webpack versions < 3.</p>
* Errors of resolving any files. <p>Reason: It happens if there is no such file in a directory. Check up url. Such error also happened when I hadn't required extensions (for example ".jsx") in webpack config file.</p>
