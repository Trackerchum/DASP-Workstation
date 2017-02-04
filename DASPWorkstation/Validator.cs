using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    class Validator
    {
        public enum ValidatorStatusCode
        {
            OK,
            
            AMPLITUDE_NOT_NUMERIC,
            AMPLITUDE_NOT_WITHIN_PARAMETERS,
            AMPLITUDE_IS_NULL,

            FREQUENCY_NOT_NUMERIC,
            FREQUENCY_NOT_WITHIN_PARAMETERS,
            FREQUENCY_IS_NULL,

            PHASE_NOT_NUMERIC,
            PHASE_NOT_WITHIN_PARAMETERS,
            PHASE_IS_NULL,
            
            NO_SINE_SELECTED_TO_EDIT,
            NO_SIGNAL_TO_PLOT
        }
    }
}
