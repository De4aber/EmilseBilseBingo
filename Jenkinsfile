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
    }
}