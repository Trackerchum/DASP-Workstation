﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class Validator
    {
        public ValidatorStatusCode ValidateSignalParamters(string amplitude, string frequency, string phase)
        {
            ValidatorStatusCode statusCode = ValidatorStatusCode.OK;
            float n;
            bool amplitudeIsNumeric = float.TryParse(amplitude, out n);
            bool frequencyIsNumeric = float.TryParse(frequency, out n);
            bool phaseIsNumeric = float.TryParse(phase, out n);


            if (amplitude == null)
            {
                statusCode = ValidatorStatusCode.AMPLITUDE_IS_NULL;
            }
            else if (amplitudeIsNumeric == false)
            {
                statusCode = ValidatorStatusCode.AMPLITUDE_NOT_NUMERIC;
            }
            else if (frequency == null)
            {
                statusCode = ValidatorStatusCode.FREQUENCY_IS_NULL;
            }
            else if (frequencyIsNumeric == false)
            {
                statusCode = ValidatorStatusCode.FREQUENCY_NOT_NUMERIC;
            }
            else if (phase == null)
            {
                statusCode = ValidatorStatusCode.PHASE_IS_NULL;
            }
            else if (phaseIsNumeric == false)
            {
                statusCode = ValidatorStatusCode.PHASE_NOT_NUMERIC;
            }
            else if (float.Parse(amplitude) <= 0 || float.Parse(amplitude) >= 10)
            {
                statusCode = ValidatorStatusCode.AMPLITUDE_NOT_WITHIN_PARAMETERS;
            }
            else if (float.Parse(frequency) < -96000 || float.Parse(frequency) > 96000)
            {
                statusCode = ValidatorStatusCode.FREQUENCY_NOT_WITHIN_PARAMETERS;
            }
            else if (float.Parse(phase) < -3600 || float.Parse(phase) > 3600)
            {
                statusCode = ValidatorStatusCode.PHASE_NOT_WITHIN_PARAMETERS;
            }

            return statusCode;
        }


        public ValidatorStatusCode ValidateDFTResolution(string resolution)
        {
            ValidatorStatusCode statusCode = ValidatorStatusCode.OK;
            int n;
            bool resolutionIsNumeric = int.TryParse(resolution, out n);

            if (resolution == null)
            {
                statusCode = ValidatorStatusCode.RESOLUTION_IS_NULL;
            }
            else if (resolutionIsNumeric == false)
            {
                statusCode = ValidatorStatusCode.RESOLUTION_NOT_NUMERIC;
            }
            else if (int.Parse(resolution) <= 0 || int.Parse(resolution) > 8000)
            {
                statusCode = ValidatorStatusCode.RESOLUTION_NOT_WITHIN_PARAMETERS;
            }

            return statusCode;
        }


        public enum ValidatorStatusCode
        {
            OK,

            AMPLITUDE_IS_NULL,
            AMPLITUDE_NOT_NUMERIC,
            AMPLITUDE_NOT_WITHIN_PARAMETERS,

            FREQUENCY_IS_NULL,
            FREQUENCY_NOT_NUMERIC,
            FREQUENCY_NOT_WITHIN_PARAMETERS,

            PHASE_IS_NULL,
            PHASE_NOT_NUMERIC,
            PHASE_NOT_WITHIN_PARAMETERS,

            RESOLUTION_IS_NULL,
            RESOLUTION_NOT_NUMERIC,
            RESOLUTION_NOT_WITHIN_PARAMETERS
        }
    }
}
