using System;

namespace UnityPID
{
    public class PIDController
    {
        // PID coefficients
        private double Kp;
        private double Ki;
        private double Kd;

        // Output limits
        private double outputMin;
        private double outputMax;

        // Integral windup limits
        private double integralMin;
        private double integralMax;

        // Internal state
        private double previousError;
        private double integral;

        // Time step
        private double deltaTime;

        // tatoloutput
        public double output;

        // Constructor
        public PIDController(double Kp = 0, double Ki = 0, double Kd = 0, double outputMin = 0, double outputMax = 0, double integralMin = 0, double integralMax = 0, double deltaTime = 0.0001)
        {
            this.Kp = Kp;
            this.Ki = Ki;
            this.Kd = Kd;
            this.outputMin = outputMin;
            this.outputMax = outputMax;
            this.integralMin = integralMin;
            this.integralMax = integralMax;
            this.deltaTime = deltaTime;
            this.previousError = 0;
            this.integral = 0;
        }

        // Compute the PID output
        public double update(double setpoint, double actual)
        {
            // Calculate error
            double error = setpoint - actual;

            // Proportional term
            double proportional = Kp * error;

            // Integral term
            integral += error * deltaTime;

            // Clamp integral to limits to avoid windup
            if (integral > integralMax) integral = integralMax;
            if (integral < integralMin) integral = integralMin;

            double integralTerm = Ki * integral;

            // Derivative term
            double derivative = (error - previousError) / deltaTime;
            double derivativeTerm = Kd * derivative;

            // Compute output
            double output = proportional + integralTerm + derivativeTerm;

            // Clamp output to limits
            if (output > outputMax) output = outputMax;
            if (output < outputMin) output = outputMin;

            // Store current error as previous error for next iteration
            previousError = error;

            this.output = output;
            return output;
        }

        // Reset the PID controller state
        public void reset()
        {
            previousError = 0;
            integral = 0;
        }
    }
}