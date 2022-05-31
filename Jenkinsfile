pipeline {
    agent any

    triggers {
        pollSCM "*/5 * * * *"
    }

    stages {

        stage ("Hello World!") {
            steps {
                sh "echo 'hello world!'"
            }
        }

        stage ("Build Backend") {
            steps {
                sh "dotnet build ."
            }
        }

        stage ("Reset Containers") {
            steps {
                script {
                    try {
                        sh "docker compose down"
                    }
                    finally {}
                }
            }
        }

        stage ("Deploy Backend") {
            steps {
                sh "docker compse up -d --build"
            }
        }
    }
}