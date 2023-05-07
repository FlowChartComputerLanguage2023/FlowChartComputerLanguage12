import io.reactivex.Observable;
import java.util.Collections;
import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;
import java.util.stream.IntStream;
import java.util.stream.Stream;

class Hangman {

	Observable<Output> play(final Observable<String> word, final Observable<String> letters) {

		final String w = word.firstElement().blockingGet();

		final Output emptyOutput =
			new Output(w,
					   "_".repeat(w.length()),
					   Collections.emptySet(),
					   Collections.emptySet(),
					   Collections.emptyList(),
					   Status.PLAYING);

		return letters.reduce(emptyOutput, this::processLetter).toObservable();
	}

	private Output processLetter(final Output output, final String letter) {

		final String discovered = IntStream.range(0, output.secret.length())
			.mapToObj(i -> output.secret.substring(i, i + 1).equals(letter) ? letter : output.discovered.substring(i, i + 1))
			.collect(Collectors.joining());

		final Set<String> guess = output.secret.contains(letter)
			? Stream.concat(output.guess.stream(), Stream.of(letter)).collect(Collectors.toSet())
			: output.guess;

		final Set<String> misses = !output.secret.contains(letter)
			? Stream.concat(output.misses.stream(), Stream.of(letter)).collect(Collectors.toSet())
			: output.misses;

		final List<Part> parts = Stream.of(Part.values()).limit(misses.size()).collect(Collectors.toList());

		return new Output(output.secret, discovered, guess, misses, parts, this.getStatus(discovered, misses.size()));
	}

	private Status getStatus(final String discovered, final int failed) {
		if (failed == Part.values().length) {
			return Status.LOSS;
		} else if (!discovered.contains("_")) {
			return Status.WIN;
		} else  {
			return Status.PLAYING;
		}
	}
}