
class ModelProxyClass {
	/**
	 * Constructs a model-based BaseClass subclass based on the className
	 * @param {string} className
	 * @param {object} genericObject
	 * @return {ModelBaseClass}
	 */
	static createByClassName(className, genericObject) {
		switch (className) {
		default:
			throw new Error('Undefined model class: ' + className);
		}
	}
}

export default ModelProxyClass;
