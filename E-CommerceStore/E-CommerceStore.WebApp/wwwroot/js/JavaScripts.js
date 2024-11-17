export function scrollLeft(element) {
    if (element) {
        element.scrollBy({
            left: -300,
            behavior: 'smooth'
        });
    }

}
export function scrollRight(element) {
    if (element) {
        element.scrollBy({
            left: 300,
            behavior: 'smooth'
        });
    }
}