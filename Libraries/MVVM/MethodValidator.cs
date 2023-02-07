using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;

// Overview of annotations: https://www.codeproject.com/Articles/1184173/DataAnnotations-in-Depth

namespace MVVM
{

    public class MethodValidator : ValidationAttribute
    {
        #region
        private MethodInfo? _validationMethod;
        private object? _classInstance;
        #endregion

        #region
        public string MethodName { get; }
        #endregion

        #region Ctor
        public MethodValidator(string methodName)
        {
            MethodName = methodName;
        }
        #endregion

        #region
        public void SetClassInstance(object instance)
        {
            _classInstance = instance;
            if (_validationMethod == null)
            {
                var typeOfInstance = instance.GetType();
                _validationMethod = typeOfInstance.GetMethod(MethodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                Debug.Assert(_validationMethod != null,
                    $"The method {MethodName} could not be found in class {_classInstance.GetType().Name}");
                Debug.Assert(_validationMethod.ReturnParameter?.ParameterType == typeof(string),
                    $"The return type of method {MethodName} is of type {_validationMethod.ReturnParameter.ParameterType.Name}, not type string in class {_classInstance.GetType().Name}");
            }
        }

        public override bool IsValid(object? value)
        {
            if (_validationMethod == null) return true;
            string? errorMessage;
            errorMessage = _validationMethod.Invoke(_classInstance, null) as string;
            if(errorMessage != null) { ErrorMessage = errorMessage; } else { ErrorMessage = ""; };
            return (string.IsNullOrWhiteSpace(ErrorMessage));
        }
        #endregion
    }
}