pipeline {
  agent any

  triggers {
    pollSCM('* * * * *')
  }

  stages {
    stage('Test') {
      steps {
        echo "Hello World"
      }
    }

    stage('Migrate DB') {
      steps {        
        dir('Grate.DB') {
          bat "grate --files=.\\db --connstring=${env.GrateConnectionString} --silent"
        }
      }
    }
  }
}