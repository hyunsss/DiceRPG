public class SingleTon<T> where T : new() {

    protected SingleTon() { }

    private static T instance;

    public static T GetInstance() {
        if(instance == null) {
            instance = new T();
        }  

        return instance;
    }

}