pipeline {

    agent any

    parameters {
        string(name:"SOLUTION_NAME", defaultValue:"NaiveWebServer.sln", description: "Solution Name")
        string(name:"SONAR_PROJECT_NAME", defaultValue:"NaiveWebServer", description: "Solution Name")
        text(name:"TEST_PROJ_PATH", defaultValue:"", description: "Test Project Path To .csproj file")

        booleanParam(name: 'BUILD', defaultValue: false, description: 'Check To Build')
        booleanParam(name: 'SONAR_ANALYSIS', defaultValue: false, description: 'Check To Sonar Analysis')
        booleanParam(name: 'TEST', defaultValue: false, description: 'Check To Test')
        booleanParam(name: 'PUBLISH', defaultValue: false, description: 'Check To Publish')
    }

    stages {
        stage('build') {
            when {
                expression { params.BUILD || params.PUBLISH || params.TEST}
            }
            steps {
                bat '''dotnet build %SOLUTION_NAME%'''
            }
        }

        
        stage('sonar') {
             when {
                expression { return params.SONAR_ANALYSIS}
            }
            steps{
                bat """
                        dotnet ${SONAR_MS_TOOL}  begin /k:"%SONAR_PROJECT_NAME%" /d:sonar.host.url=${SONAR_URL}  /d:sonar.login="${SONAR_TOKEN}"
                        dotnet  build
                        dotnet ${SONAR_MS_TOOL} end  /d:sonar.login="${SONAR_TOKEN}"
                    """
            }     
        }

        stage('publish') {
             when {
                expression { return params.PUBLISH || params.DEPLOY }
            }
            steps {
                bat '''dotnet publish %SOLUTION_NAME% -p:Configuration=release -v:q -o ../artifacts'''
            }
        }

        



        
    }
  
}